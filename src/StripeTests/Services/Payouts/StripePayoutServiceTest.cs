namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripePayoutServiceTest : BaseStripeTest
    {
        private const string PayoutId = "po_123";

        private StripePayoutService service;
        private StripePayoutCreateOptions createOptions;
        private StripePayoutUpdateOptions updateOptions;
        private StripePayoutListOptions listOptions;

        public StripePayoutServiceTest()
        {
            this.service = new StripePayoutService();

            this.createOptions = new StripePayoutCreateOptions()
            {
                Amount = 123,
                Currency = "usd",
            };

            this.updateOptions = new StripePayoutUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new StripePayoutListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var payout = this.service.Create(this.createOptions);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var payout = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public void Cancel()
        {
            var payout = this.service.Cancel(PayoutId);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public async Task CancelAsync()
        {
            var payout = await this.service.CancelAsync(PayoutId);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public void Get()
        {
            var payout = this.service.Get(PayoutId);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var payout = await this.service.GetAsync(PayoutId);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public void List()
        {
            var payouts = this.service.List(this.listOptions);
            Assert.NotNull(payouts);
            Assert.Equal("list", payouts.Object);
            Assert.Single(payouts.Data);
            Assert.Equal("payout", payouts.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var payouts = await this.service.ListAsync(this.listOptions);
            Assert.NotNull(payouts);
            Assert.Equal("list", payouts.Object);
            Assert.Single(payouts.Data);
            Assert.Equal("payout", payouts.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var payout = this.service.Update(PayoutId, this.updateOptions);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var payout = await this.service.UpdateAsync(PayoutId, this.updateOptions);
            Assert.NotNull(payout);
            Assert.Equal("payout", payout.Object);
        }
    }
}
