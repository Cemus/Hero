using Hero.Shared.Models;

namespace Hero.API.Builders
{
    public class OutcomeBuilder
    {
        private readonly Outcome _outcome = new()
        {
            Label = "",
            FeedBack = "",
            Effects = [],
            Conditions = [],
        };

        public OutcomeBuilder SetLabel(string label)
        {
            _outcome.Label = label;
            return this;
        }

        public OutcomeBuilder SetFeedBack(string feedBack)
        {
            _outcome.FeedBack = feedBack;
            return this;
        }

        public OutcomeBuilder AddEffect(Effect effect)
        {
            _outcome.Effects.Add(effect);
            return this;
        }

        public OutcomeBuilder AddCondition(Condition condition)
        {
            _outcome.Conditions.Add(condition);
            return this;
        }

        public Outcome Build()
        {
            return _outcome;
        }
    }

}
