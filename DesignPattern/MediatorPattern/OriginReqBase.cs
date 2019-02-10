namespace MediatorPattern
{
    public abstract class OriginReqBase
    {
        protected ProductManager _productManager;

        protected OriginReqBase(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public virtual void Requirement(string message)
        {
            _productManager.Send(message, this);
        }
    }
}