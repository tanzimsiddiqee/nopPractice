using FluentMigrator;
using Nop.Core.Domain.Polls;

namespace Nop.Data.Migrations
{
    [NopMigration("2022/03/04 16:38:30:2551770", "Poll. Add TestProperty", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class AddTestProperty: AutoReversingMigration
    {
        public override void Up()
        {
            Create.Column(nameof(Poll.TestProperty))
                 .OnTable(nameof(Poll))
                 .AsString(255)
                 .Nullable();
        }
    }
}
