using System.ComponentModel.DataAnnotations;
using AlloyTemplates.Business.Attributes;
using AlloyTemplates.Models.Blocks.SubBlocks;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AlloyTemplates.Models.Blocks
{
    [SiteContentType(GUID = "187C3032-6D88-45BD-8455-4A8007E390C9")] // BEST PRACTICE TIP: Always assign a GUID explicitly when creating a new block type
    [SiteImageUrl]
    public class OnPageNavigationBlock : SiteBlockData
    {
        [Display(Name = "Show blue background", Description = "Instead of default white", Order = 10)]
        public virtual bool ShowBlueBackground { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Image", Description = "300 x 350 px", Order = 100)]
        public virtual ContentReference Image { get; set; }

        [Required]
        [CultureSpecific]
        [Display(Name = "Title", Description = "", Order = 200)]
        public virtual string Title { get; set; }

        [MinMax(Min = 4, Max = 10)]
        [AllowedTypes(new[] { typeof(OnPageNavigationItem) })]
        [Display(Name = "Items", Description = "Min. 4, Max. 10 items", Order = 300)]
        public virtual ContentArea Items { get; set; }
    }
}
