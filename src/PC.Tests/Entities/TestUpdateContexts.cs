using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PebbleCode.Entities;

namespace PebbleCode.Tests.Entities
{
    public class TestUpdateContextConstants
    {
        internal const int PebbleAdmin = 50;
        internal const int HigherUser = 50;
        internal const int LowerUser = 40;
        internal const int Migration = -1;
    }

    public sealed class PebblecodeUpdateContexts : UpdateContext<TestUpdateContextConstants>
    {
        private PebblecodeUpdateContexts(string name, params ConcreteControlledUpdateEntity[] entities)
            : base(name, entities)
        {
        }

        public static PebblecodeUpdateContexts PebbleAdmin(params ConcreteControlledUpdateEntity[] entities)
        {
            return new PebblecodeUpdateContexts("PebbleAdmin", entities);
        }

        public static PebblecodeUpdateContexts HigherUser(params ConcreteControlledUpdateEntity[] entities)
        {
            return new PebblecodeUpdateContexts("HigherUser", entities);
        }

        public static PebblecodeUpdateContexts LowerUser(params ConcreteControlledUpdateEntity[] entities)
        {
            return new PebblecodeUpdateContexts("LowerUser", entities);
        }

        public static PebblecodeUpdateContexts Migration(params ConcreteControlledUpdateEntity[] entities)
        {
            return new PebblecodeUpdateContexts("Migration", entities);
        }
    }
}
