namespace Lib.field.generate;


[Guid("860da1cd-b341-4bc5-965a-4a9c295831f4")]
internal sealed class RoundedBoxField : Instance<RoundedBoxField>, IGraphNodeOp
{
    [Output(Guid = "9153c53c-0b19-4ce4-b086-e448d78ef032")]
    public readonly Slot<ShaderGraphNode> Result = new();

    public RoundedBoxField()
    {
        ShaderNode = new ShaderGraphNode(this);
        Result.Value = ShaderNode;
        Result.UpdateAction += Update;
    }

    private void Update(EvaluationContext context)
    {
        ShaderNode.Update(context);
    }
    
    public ShaderGraphNode ShaderNode { get; }
    public void GetShaderCode(StringBuilder shaderStringBuilder, Dictionary<string, string> globals)
    { 
        shaderStringBuilder.AppendLine( $@"
float {ShaderNode}(float3 p) {{
   float3 q = abs(p- {ShaderNode}Center) - {ShaderNode}Size + {ShaderNode}Radius;
   return length(max(q,0.0)) + min(max(q.x,max(q.y,q.z)),0.0) - {ShaderNode}Radius;
}}
");
    }
    
    [GraphParam]
    [Input(Guid = "951b2983-1359-41e4-8fb0-8d97c50ed8d6")]
    public readonly InputSlot<Vector3> Center = new();
    
    [GraphParam]
    [Input(Guid = "C4EF07B4-853B-48D4-9ADE-C93EE849071A")]
    public readonly InputSlot<Vector3> Size = new();
    
    [GraphParam]
    [Input(Guid = "787e5d70-0aba-400f-8616-6ece6c5895bc")]
    public readonly InputSlot<float> Radius = new();
}

