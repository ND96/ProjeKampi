using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Maili boş geçilemez!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPassword).Matches(@"^(?=.*[a-z])(?=.*[A-Z]).+$").WithMessage("Şifreyi en az bir büyük bir küçük harf ile oluşturmanız gerekmektedir.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 Karakter girebilirsiniz");
        }
    }
}
