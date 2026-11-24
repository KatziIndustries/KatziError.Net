# KatziError
C# bindings for KatziError

# Usage
```
KerrorWindow error = new()
{
    Title = "Swaggy title",
    Text = "Very cool text",
    ButtonCount = 2,
    Button1 = "UwU",
    Button2 = "OwO",
    ProgessActive = false,
    Progress = 0.5f,
};

bool running = true;
while (running)
{
    int result = error.Pull();

    if (result != 0)
        running = false;
}

error.Dispose();
```

# Including in your project
```
dotnet add package KatziError.Net
```
