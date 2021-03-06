namespace Stripe.Issuing
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AuthorizationControls : StripeEntity
    {
        [JsonProperty("allowed_categories")]
        public List<string> AllowedCategories { get; set; }

        [JsonProperty("blocked_categories")]
        public List<string> BlockedCategories { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("max_amount")]
        public int MaxAmount { get; set; }

        [JsonProperty("max_approvals")]
        public int MaxApprovals { get; set; }
    }
}