using EPiServer.Core;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyTemplates.Models.Blocks.SubBlocks
{
    [SiteContentType(GUID = "94B8E8A6-B378-48F0-8D8D-323A1CFA3575")] // BEST PRACTICE TIP: Always assign a GUID explicitly when creating a new block type
    [SiteImageUrl]
    public class OnPageNavigationItem : SiteBlockData
    {
        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Icon", Description = "26 x 22 px", Order = 100)]
        public virtual ContentReference Icon { get; set; }
    }
}
