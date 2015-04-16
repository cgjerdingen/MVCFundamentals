using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using WebGrease.Css.Visitor;

namespace MVCFundamentals.Models
{
    public class TrailReview
    {
        public int Id { get; set; }
        [Required]
        [Range(0,5)]
        public decimal Rating { get; set; }
        [Display(Name = "Your Review")]
        [StringLength(4000)]
        [NoCursing]
        public string Body { get; set; }
        public int TrailId { get; set; }
        [Display(Name="Reviewer Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }
    }

    class NoCursing : ValidationAttribute
    {
        public NoCursing()
            : base("{0} contains inappropriate words")
        {
            LoadInappropriateWordsList();

        }

        private void LoadInappropriateWordsList()
        {
            //add items from your dictionary to the list
            InappropriateWordsList = "fuck fucking fucker fucked fuckhead fuckwad fucknuts".Split(' ').ToList();

            //throw new NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);  
            if (value != null)
            {
                var valAsString = value.ToString();
                if (valAsString.ToLower().Split(' ').Intersect(InappropriateWordsList).Any())
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        private List<string> InappropriateWordsList { get; set; }
    }
}