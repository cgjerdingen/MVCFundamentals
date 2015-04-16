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
        [NoCursing(ErrorMessage = "Do you talk to your mother with that mouth!? Watch the language in {0}!")]
        public string Body { get; set; }
        public int TrailId { get; set; }
        [Display(Name="Reviewer Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }
    }

    class NoCursing : ValidationAttribute
    {
        public NoCursing()
            : base("{0} contains inappropriate words; no cursing!")
        {
            LoadInappropriateWordsList();

        }

        private void LoadInappropriateWordsList()
        {
            //add items from your dictionary to the list
            //wouldn't want the model to own a list. 
            //May be the badword list would be a model of its own and filled using the DBContext or some repository method.
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