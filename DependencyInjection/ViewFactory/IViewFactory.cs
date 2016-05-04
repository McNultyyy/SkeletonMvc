using System.Web.UI.WebControls;

namespace DependencyInjection.ViewFactory
{
    public interface IViewFactory
    {
        TView CreateView<TView>();
        TView CreateView<TInput, TView>(TInput input);
    }
}