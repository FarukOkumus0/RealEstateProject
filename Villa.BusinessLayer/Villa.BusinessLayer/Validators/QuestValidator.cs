using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.BusinessLayer.Validators
{
	public class QuestValidator : AbstractValidator<Quest>
	{
		public QuestValidator()
		{
			RuleFor(x => x.Question).NotEmpty().WithMessage("Soru boş bırakılamaz.");
			RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap boş bırakılamaz.");

		}
	}
}
