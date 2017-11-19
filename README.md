# web-service-19-11-2560
workshop in web service class

> ### อาทิตย์หน้า(26/11/2560) => สอบปฏิบัติ <br>
> ### อาทิตย์ถัดไป(3/12/2560) => สอบปลายภาค(ข้อเขียน)

## note
WCF => เหมาะสำหรับ service ที่มีการ read write
API => เหมาะสมกับ service ที่มีการ read อย่างเดียวเท่านั้น

## ASP.NET Framework
### MVC 
> - M : Model (Data) => ORM connect to DBMS
> - V : View (คือส่วนจัดการแสดงข้อมูล) => 
> - C : Controller (Control)


### App_Start
- BundleConfig.cs => จัดการเกี่ยวกับ asset(javascript, css)
- FilterConfig.cs => 

### step
1. Route
2. Controller
3. Method

### Route => `App_Start/RouteConfig.cs` 
```c#
public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );

        // ** note
        // new { } คือ anonymous object
    }
}
```

### Controller => `Controller/HomeController/{ActionName}`
```c#
// ... class
    public ActionResult Hello(string msg)
    {
        // dynamic property(ถังกลางข้อมูล) คือการจับข้อมูลลงถังกลาง โดยโยน message
        ViewBag.Message = "Hello : " + msg; 
        return View();
    }
// ... end class
```

### View => `Views/Home/{ActionName}`
> add view 
1. click right in block actionName > add view 
2. default name file
3. add layout `Views/Shared/_Layout.cshtml`

> goto view
1. click right in block actionName > go to view

```html
<h1>@ViewBag.Message</h1>
<!-- example :  http://localhost/Home/Hello?msg=John -->
```

### URL 