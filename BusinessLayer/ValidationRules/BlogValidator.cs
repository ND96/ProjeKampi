using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını boş geçemezsiniz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini boş geçemezsiniz!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görselini boş geçemezsiniz!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakteri geçmeyiniz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden fazla giriniz");
        }
    
    }
}
