using FluentValidation;
using HotelProject.WebUI.Dtos.SendMessageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ValidationRules.AdminContactValidationRules
{
    public class SendMessageValidator : AbstractValidator<CreateSendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı email adresi boş olamaz");
            RuleFor(x => x.ReceiverName).NotEmpty().WithMessage("Alıcı isim bilgisi boş olamaz");
        }
    }
}
