using Autofac;


namespace BookMarking.Common.AutoFac
{
    public class BMAutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //程序集批量注册
            var assemblies = Helpers.ReflectionHelper.GetAllAssembliesCoreWeb();
            //注册仓储
            builder.RegisterAssemblyTypes(assemblies)
                .Where(cc => cc.Name.EndsWith("Repository") || cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）
        }
    }
}
