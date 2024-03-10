using WebApi.Service.Interface;

namespace WebApi.Service;

public class Service: IService
{
    public string ValidateTemp(int temp)
    {
        if (temp < 0)
        {
            return "invalid";
        }

        return "valid";
    }
}