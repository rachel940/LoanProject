using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BL.Implementation
{
    public class ReflectionInterestStrategyFactory : IInterestStrategyFactory
    {
        private readonly IEnumerable<Type> _strategyTypes;

        public ReflectionInterestStrategyFactory()
        {
            // Finding all classes that implement the IInterestCalculationStrategy interface
            _strategyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IInterestCalculationStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        }

        public IInterestCalculationStrategy CreateStrategy(int age)
        {
            foreach (var type in _strategyTypes)
            {
                var strategy = (IInterestCalculationStrategy)Activator.CreateInstance(type);
                if (strategy != null && strategy.MatchesClientAge(age))
                {
                    return strategy;
                }
            }
            throw new InvalidOperationException("No matching strategy found for the given age.");
        }
    }
}
