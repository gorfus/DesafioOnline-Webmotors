using FluentValidation.Results;
using MediatR;
using System;

namespace WB.DesafioOnline.Anuncios.Core
{
    public abstract class Command :  IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
