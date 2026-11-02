# Task Search
## الفرق بين Protected Internal و Private Protected في C#

في لغة C# عندنا حاجة اسمها **Access Modifiers**، ودي بنستخدمها علشان نحدد مين يقدر يوصل للمتغيرات والـ Methods اللي جوه الـ Class.

### 1. Protected Internal

دي معناها إن أي Class موجود في نفس الـ Assembly يقدر يوصل للعضو، حتى لو مش وارث من الـ Class الأصلي.

وكمان أي Class وارث منه يقدر يوصل له، حتى لو موجود في Assembly تانية.

يعني باختصار: **نفس الـ Assembly أو Inheritance**.

**مثال:**

```csharp
class Person
{
    protected internal string Name = "Ahmed";
}

class Student : Person
{
    public void Show()
    {
        Console.WriteLine(Name);
    }
}
```

هنا `Student` قدر يستخدم `Name` لأنه وارث من `Person`.

### 2. Private Protected

دي أضيق شوية في الصلاحيات، لأنها بتسمح بالوصول للعضو من نفس الـ Class، أو من Class وارث منه بشرط يكون في نفس الـ Assembly.

يعني باختصار: **Inheritance + نفس الـ Assembly**.

**مثال:**

```csharp
class Person
{
    private protected int Age = 20;
}

class Student : Person
{
    public void Show()
    {
        Console.WriteLine(Age);
    }
}
```

هنا `Student` قدر يستخدم `Age` لأنه وارث من `Person` وموجود معاه في نفس الـ Assembly.

### الفرق بينهم باختصار

| Protected Internal | Private Protected |
|---|---|
| نفس الـ Assembly أو Class وارث | Class وارث وفي نفس الـ Assembly |
| صلاحياته أوسع | صلاحياته أقل |
| بيعتمد على OR | بيعتمد على AND |

### الخلاصة

أنا فهمت إن الفرق الأساسي بينهم هو إن `protected internal` بيسمح بوصول أكبر، إنما `private protected` بيكون أكثر تقييدًا.

وبنستخدم الاتنين علشان نتحكم في الوصول للبيانات ونطبق مفهوم الـ **Encapsulation** في الـ OOP.
