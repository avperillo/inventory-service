using DDD.abstracts;

namespace Inventory.Domain.Aggregates.Items
{
    public class ItemType : Enumeration
    {
        public static ItemType Unknow = new UnknowItemType();

        protected ItemType(int id, string name) : base(id, name) { }

        private class UnknowItemType : ItemType
        {
            public UnknowItemType() : base(1, "Unknow") { }
        }

    }
}
