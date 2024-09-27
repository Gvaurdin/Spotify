using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Spotify.Application.Models.Behavior
{
    /// <summary>
    /// Поведение конвейера (pipeline behavior) для валидации запросов.
    /// Реализует интерфейс IPipelineBehavior из библиотеки MediatR.
    /// </summary>
    /// <typeparam name="TRequest">Тип запроса, который будет обрабатываться.</typeparam>
    /// <typeparam name="TResponse">Тип ответа, возвращаемого обработчиком запроса.</typeparam>
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : // Коллекция валидаторов для данного типа запроса
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>// Ограничение: TRequest должен реализовывать IRequest<TResponse>
        /// <summary>
        /// Конструктор класса ValidationBehavior.
        /// Принимает коллекцию валидаторов, внедренных через Dependency Injection.
        /// </summary>
        /// <param name="validators">Коллекция валидаторов для TRequest.</param>
    {
        /// <summary>
        /// Метод, реализующий логику поведения конвейера.
        /// Выполняет валидацию запроса перед его обработкой.
        /// </summary>
        /// <param name="request">Текущий запрос, который обрабатывается.</param>
        /// <param name="next">Делегат для вызова следующего обработчика в конвейере.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронных операций.</param>
        /// <returns>Задача, возвращающая ответ типа TResponse.</returns>
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Создаём контекст валидации на основе текущего запроса
            var context = new ValidationContext<TRequest>(request);
            var failures = validators
                // Для каждого валидатора вызываем метод Validate, передавая контекст валидации
                .Select(v => v.Validate(context))
                // Объединяем все ошибки из результатов валидации в одну коллекцию
                .SelectMany(result => result.Errors)
                // Фильтруем коллекцию, оставляя только ненулевые ошибки
                .Where(failure => failure != null)
                // Преобразуем результирующую последовательность в список
                .ToList();

            // Проверяем, были ли найдены ошибки валидации
            if (failures.Count != 0)
            {
                // Если ошибки есть, выбрасываем исключение ValidationException с коллекцией ошибок
                throw new ValidationException(failures);
            }

            // Если ошибок нет, передаём управление следующему обработчику в конвейере
            return next();
        }
    }
}
