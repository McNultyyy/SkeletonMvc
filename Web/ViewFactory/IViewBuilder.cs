namespace Web.ViewFactory
{
    public interface IViewBuilder<in TInput, out TView>
    {
        TView Build(TInput input);
    }

    public interface IViewBuilder<out TView>
    {
        TView Build();
    }
}