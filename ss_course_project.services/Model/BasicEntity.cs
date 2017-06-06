using System;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public class BasicEntity : IBasicEntity
    {
        /*-------------------------------------------------------------------*/

        public Guid Id { get; private set; }

        /*-------------------------------------------------------------------*/

        protected BasicEntity() { }

        /*-------------------------------------------------------------------*/

        public BasicEntity(Guid id)
        {
            this.Id = id;
        }

        /*-------------------------------------------------------------------*/

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /*-------------------------------------------------------------------*/

        public override bool Equals(object obj)
        {
            return
                obj is BasicEntity
                &&
                this.Id == (obj as BasicEntity).Id;
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
