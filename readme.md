# Urho.WPF test app 

Simple test app to reproduce potential memory leak in the Urho WPF bindings.

## The test app
The app switches between two user controls, one empty and one with a ```UrhoSurface``` WPF element as below.

```xml
<UserControl x:Class="UrhoTestApp.UserControl2"
...
>
    <Grid x:Name="Grid1">
        <TextBlock>User control 2</TextBlock>
        <wpf:UrhoSurface x:Name="Urho1">
        </wpf:UrhoSurface>
    </Grid>
</UserControl>
```

A new instance of the user controls is created when the user navigates to it. The previously visible user control is then removed from the visual tree. 

## The potential memory leak
This works perfectly fine with the empty user control but the UrhoSurface object is never garbage collected and after a while there will be lots of UrhoSurface objects in memory. 

Below is a dependency graph from ANTS memory profiler and it seems like there is something input event handling that keeps a reference to the ```UrhoSurface``` preventing it from being garbage collected.


![](memoryleak_testapp.png)