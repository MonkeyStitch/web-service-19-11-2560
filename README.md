# web-service-19-11-2560
workshop in web service class

> ### อาทิตย์หน้า(26/11/2560) => สอบปฏิบัติ WCF <br> 
> ### อาทิตย์ถัดไป(3/12/2560) => สอบปลายภาค(ข้อเขียน)

## note
WCF => เหมาะสำหรับ service ที่มีการ read write
API => เหมาะสมกับ service ที่มีการ read อย่างเดียวเท่านั้น

where you type ให้สามารถเป็นค่าว่างได้ต้องใส่ ? : `int? id`
reference type : `Object`

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
        // new { } คือ anonymous type
    }
}
```

# Basic 1

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

# Basic 2

### Model
> add new item
1. select Data
2. ADO.NET Entity Data Model > rename "EmployeeContext"
3. empty code first model
4. Ok.

***
web.config * connectionString
***

> add model class
1. click right "Model" folder
2. add > class > rename "Employee"
3. Ok.
```c#
public class Employee
{
    public int ID { get; set; }

    [Required]
    [Display(Name = "ชื่อ-สกุล")]
    public string FullName { get; set; }

    [Display(Name = "เพศ")]
    public string Gender { get; set; }

    [Display(Name = "เงินเดือน")]
    public decimal Salary { get; set; }
}
```
***
* note สร้างเสร็จแล้วต้อง build ก่อนเสมอเพื่อให้เป็น stong type
***

### Controller
> add controller
1. click right `Controllers` folder 
2. add > Controller
3. select `MVC 5 Controller with views, using Entity Framework` 
4. click Add
5. select Model Class `Employee (DemoMVCWeb.Models)` <mark>*ต้อง complie หรือ buile project ก่อน</mark>
6. select Data Context Class `EmployeeContext (DemoMVCWeb)` <mark>*ต้อง complie หรือ buile project ก่อน</mark>
7. rename Controller name "EmployeeController"
8. click add

#### result หลังจากสร้าง controller แบบ `MVC 5 Controller with views, using Entity Framework` 
- Controllers/EmployeeController.cs
- Views/Employee/Create.cshtml
- Views/Employee/Delete.cshtml
- Views/Employee/Details.cshtml
- Views/Employee/Edit.cshtml
- Views/Employee/Index.cshtml

### Method
<mark> methods </mark>
> `include` คือจะเลือกรับเฉพาะ ข้อมูลที่กำหนดเท่านั้น
> `[ValidateAntiForgeryToken]` ตรวจสอบ token
> `[ActionName("")]` เปลี่ยนชื่อ  
> `ModelState.IsValid` ตรวจสอบชนิดข้อมูล ที่รับเข้ามา
```c#
    // POST: Employee/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,FullName,Gender,Salary")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(employee);
    }

    // POST: Employee/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Employee employee = db.Employees.Find(id);
        db.Employees.Remove(employee);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
```
<mark> การบังคับปิด ค่าตัวแปร ที่ใช้ ในที่นี้บังคับปิด</mark> `db` 
```c#
protected override void Dispose(bool disposing)
{
    if (disposing)
    {
        db.Dispose(); 
    }
    base.Dispose(disposing);
}
```

### view
> `@model`
```html
<!-- multi record -->
@model IEnumerable<DemoMVCWeb.Models.Employee>
<!-- one record -->
@model DemoMVCWeb.Models.Employee
```
> `ViewBag`
```html
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```
> `HTML Helper`
```html
<!-- Create จะวิ่งไปที่ method Create ใน Controller ของตัวมันเอง ในที่นี้คือ EmployeeController -->
@Html.ActionLink("Create New", "Create")

<!-- create form -->
@using (Html.BeginForm()) 
{
    <!-- token use in my web -->
    @Html.AntiForgeryToken()

}
```