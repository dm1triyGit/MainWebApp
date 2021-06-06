using AutoMapper;

namespace WebUI.Mapping
{
    public static class MapperCreater
    {
        public static IMapper CreateMapperConfig()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
