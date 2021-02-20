using FluentValidation;
using System;
using TesteWevo.Application.Domain.Enums;

namespace TesteWevo.Application.Domain.DTOs.Requests.Validators
{

    public class PersonSaveRequestValidator : AbstractValidator<PersonSaveRequest>
    {

        public PersonSaveRequestValidator()
        {

            RuleFor(x => x.DataNascimento)
                .GreaterThan(new DateTime(1900, 01, 01))
                .When(x => !x.DataNascimento.Equals(DateTime.MinValue))
                .WithMessage("{PropertyName} deve ser maior que {ComparisonValue} caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !(x.Email is null))
                .WithMessage("{PropertyName} deve ser válido.");

            RuleFor(x => x.Email)
                .MaximumLength(200)
                .When(x => !(x.Email is null))
                .WithMessage("{PropertyName} deve conter menos de {MaxLength} caracteres.");

            RuleFor(x => x.Nome)
                .MaximumLength(100)
                .When(x => !(x.Nome is null))
                .WithMessage("{PropertyName} deve conter menos de {MaxLength} caracteres.");

            RuleFor(x => x.Sexo)
                .Must(x => Enum.IsDefined(typeof(Gender), (int)x))
                .When(x => !(0).Equals((int)x.Sexo))
                .WithMessage("{PropertyName} com valor inválido (1 ou 2).");

            RuleFor(x => x.Telefone)
                .MaximumLength(20)
                .When(x => !(x.Telefone is null))
                .WithMessage("{PropertyName} deve conter menos de {MaxLength} caracteres.");

            RuleSet("Insert",
                    () =>
                    {

                        RuleFor(x => x.CPF)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                        RuleFor(x => x.DataNascimento)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                        RuleFor(x => x.Email)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                        RuleFor(x => x.Nome)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                        RuleFor(x => x.Sexo)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                        RuleFor(x => x.Telefone)
                            .NotEmpty()
                            .WithMessage("{PropertyName} deve ser preenchido.");

                    });

        }

    }

}
