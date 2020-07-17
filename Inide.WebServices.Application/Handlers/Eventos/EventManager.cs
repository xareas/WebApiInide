using System;
using System.Collections.Generic;
using System.Text;

namespace Inide.WebServices.Application.Handlers.Eventos
{
    public class EventManager : IEventManager
    {
        public EventDeleted.Query Delete => new EventDeleted.Query();
        public EventGetAll.Query GetAll => new EventGetAll.Query();
        public EventGetById.Query GetById => new EventGetById.Query();
        public EventGetCategory.Query GetCategory => new EventGetCategory.Query();
        public EventGetPaged.Query GetPaged => new EventGetPaged.Query();
        public EventPost.Query Post => new EventPost.Query();
        public EventPut.Query Put => new EventPut.Query();
    }

    public interface IEventManager
    {
        public EventDeleted.Query Delete { get;  }
        public EventGetAll.Query GetAll { get;  }
        public EventGetById.Query GetById { get;  }
        public EventGetCategory.Query GetCategory { get;  }
        public EventGetPaged.Query GetPaged { get;  }
        public EventPost.Query Post { get;  }
        public EventPut.Query Put { get;  }
    }
}
