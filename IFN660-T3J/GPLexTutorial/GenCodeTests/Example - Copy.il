.assembly Helloworld { }
.class public Helloworld 
{
.method public static void Main(string[] args)
{
.entrypoint
.locals init ([0] int32 x)
ldc.i4 42
stloc x
ldloc x
pop
ldloc x
ldc.i4 2
add
stloc x
ldstr      "X = {0}"
ldloc x
box        [mscorlib]System.Int32
call       void [mscorlib]System.Console::WriteLine(string, object)
nop
ret
}
}