namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class StripeOAuthTokenService : StripeService
    {
        public StripeOAuthTokenService()
            : base(null)
        {
        }

        public StripeOAuthTokenService(string apiKey)
            : base(apiKey)
        {
        }

        public virtual StripeOAuthToken Create(StripeOAuthTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeOAuthToken>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, Urls.OAuthToken, false),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual StripeOAuthDeauthorize Deauthorize(string clientId, string stripeUserId, StripeRequestOptions requestOptions = null)
        {
            var url = ParameterBuilder.ApplyParameterToUrl(Urls.OAuthDeauthorize, "client_id", clientId);
            url = ParameterBuilder.ApplyParameterToUrl(url, "stripe_user_id", stripeUserId);

            return Mapper<StripeOAuthDeauthorize>.MapFromJson(
                Requestor.PostString(url, this.SetupRequestOptions(requestOptions)));
        }

        public virtual async Task<StripeOAuthToken> CreateAsync(StripeOAuthTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeOAuthToken>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, Urls.OAuthToken, false),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<StripeOAuthDeauthorize> DeauthorizeAsync(string clientId, string stripeUserId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = ParameterBuilder.ApplyParameterToUrl(Urls.OAuthDeauthorize, "client_id", clientId);
            url = ParameterBuilder.ApplyParameterToUrl(url, "stripe_user_id", stripeUserId);

            return Mapper<StripeOAuthDeauthorize>.MapFromJson(
                await Requestor.PostStringAsync(
                    url,
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }
    }
}
