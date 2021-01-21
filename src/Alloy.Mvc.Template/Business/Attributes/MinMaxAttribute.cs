using EPiServer.Core;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlloyTemplates.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinMaxAttribute : ValidationAttribute
    {
        public int Min
        {
            get;
            set;
        }
        public int Max
        {
            get;
            set;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value != null) && !(value is ContentArea) && !(value is LinkItemCollection))
            {
                throw new ValidationException("MinMaxAttribute is intended only for use with ContentArea or LinkItemCollection properties");
            }

            var contentArea = value as ContentArea;
            var linkItemCollection = value as LinkItemCollection;

            var minError = false;
            var maxError = false;

            var min = Min;
            var max = Max;

            if (contentArea != null || linkItemCollection != null)
            {
                var items = contentArea?.Items.Select(c => c.ContentLink).Count() ?? linkItemCollection.Count;

                if (min > 0 && items < min)
                {
                    minError = true;
                }
                if (max > 0 && items > max)
                {
                    maxError = true;
                }
            }
            else if (min > 0)
            {
                minError = true;
            }

            if (minError || maxError)
            {
                if (max > 0 && min > 0)
                {
                    if (min == max)
                    {
                        ErrorMessage = string.Format("Number of items for property '{0}' should be {1}", validationContext.DisplayName, min);
                    }
                    else
                    {
                        ErrorMessage = string.Format("Number of items for property '{0}' should be between {1} and {2}", validationContext.DisplayName, min, max);
                    }
                }
                else if (max > 0)
                {
                    ErrorMessage = string.Format("Number of items for property '{0}' should be maximum {1}", validationContext.DisplayName, max);
                }
                else
                {
                    ErrorMessage = string.Format("Number of items for property '{0}' should be minimum {1}", validationContext.DisplayName, min);
                }

                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
