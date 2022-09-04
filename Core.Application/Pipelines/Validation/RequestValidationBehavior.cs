using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Core.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            ValidationContext<object> validationContext = new(request);
            List<ValidationFailure> validationFailures = _validators
                                                        .Select(v => v.Validate(validationContext))
                                                        .SelectMany(r => r.Errors)
                                                        .Where(f => f != null)
                                                        .ToList();
            if (validationFailures.Count != 0) throw new ValidationException(validationFailures);
            return next();
        }
    }
}
