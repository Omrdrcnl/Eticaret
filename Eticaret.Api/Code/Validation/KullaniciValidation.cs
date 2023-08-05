using Eticaret.Model;
using FluentValidation;

namespace Eticaret.Api.Code.Validation
{
    public class KullaniciValidation: AbstractValidator<Kullanici>
    {
        public KullaniciValidation()
        {
            RuleFor(k => k.KullaniciAdi).NotEmpty().WithMessage("Kullanici Adi Boş Geçilmez");

            RuleFor(k => k.KullaniciAdi).EmailAddress().WithMessage("Hatalı Email adresi");
            RuleFor(k => k.Sifre).Length(3,15).WithMessage("Şifer en az 6 en cok 15 karakter olabilr");


        }


    }
}
