using InvoiceManager.Infrastructure.Constants;
using InvoiceManager.Model.Base;
using System;

namespace InvoiceManager.DataAccess.Events
{
    public class EventAudit : IEventAudit
    {
        //private readonly IUserRepository _userRepository;

        //public EventAudit(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        public void OnPreInsert(object entity)
        {
            if (entity is IAuditInfo)
                SetAudit(entity, EEventType.Create);
        }

        public void OnPreUpdate(object entity)
        {
            if (entity is IAuditInfo)
                SetAudit(entity, EEventType.Update);
        }

        public void OnPreDelete(object entity)
        {
            if (entity is IAuditInfo)
                SetAudit(entity, EEventType.Delete);
        }

        public void OnPreInsertForSystem(object entity)
        {
            if (entity is IAuditInfo)
                SetAuditForSystem(entity, EEventType.Create);
        }

        public void OnPreUpdateForSystem(object entity)
        {
            if (entity is IAuditInfo)
                SetAuditForSystem(entity, EEventType.Update);
        }

        public void OnPreDeleteForSystem(object entity)
        {
            if (entity is IAuditInfo)
                SetAuditForSystem(entity, EEventType.Delete);
        }

        private void SetAudit(object entity, EEventType eventType)
        {
            //var id = _userRepository.FindUserByPublicKey(publicKey).Id;
            SetAuditToEntity(entity, eventType, 1);
        }

        private void SetAuditForSystem(object entity, EEventType eventType)
        {
            var id = GlobalConstants.SystemUserId;
            SetAuditToEntity(entity, eventType, id);
        }

        private void SetAuditToEntity(object entity, EEventType eventType, int id)
        {
            var entityToAudit = entity as IAuditInfo;
            var today = DateTime.Now;

            switch (eventType)
            {
                case EEventType.Create:
                    entityToAudit.CreatedBy = id;
                    entityToAudit.CreatedOn = today;
                    entityToAudit.ModifiedBy = id;
                    entityToAudit.ModifiedOn = today;
                    if (entity is IDeletable)
                    {
                        var entityDeletable = entity as IDeletable;
                        entityDeletable.IsActive = GlobalConstants.Activated;
                    }
                    break;
                case EEventType.Update:
                    entityToAudit.ModifiedBy = id;
                    entityToAudit.ModifiedOn = today;
                    break;
                case EEventType.Delete:
                    entityToAudit.ModifiedBy = id;
                    entityToAudit.ModifiedOn = today;
                    if (entity is IDeletable)
                    {
                        var entityDeletable = entity as IDeletable;
                        entityDeletable.IsActive = GlobalConstants.Deactivated;
                    }
                    break;
            }
        }
    }
}
