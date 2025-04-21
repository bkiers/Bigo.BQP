using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateAggregateJsFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TEMP AGGREGATE FUNCTION SumPositive(x FLOAT64)\nRETURNS FLOAT64\nLANGUAGE js\nAS r'''\n  export function initialState() {\n    return {sum: 0}\n  }\n  export function aggregate(state, x) {\n    if (x > 0) {\n      state.sum += x;\n    }\n  }\n  export function merge(state, partialState) {\n    state.sum += partialState.sum;\n  }\n  export function finalize(state) {\n    return state.sum;\n  }\n'''")]
    [InlineData("CREATE OR REPLACE AGGREGATE FUNCTION my_project.my_dataset.WeightedAverage(\n    x INT64,\n    weight FLOAT64,\n    initialSum FLOAT64 NOT AGGREGATE)\nRETURNS INT64\nLANGUAGE js\nAS '''\n   export function initialState(initialSum) {\n     return {count: 0, sum: initialSum}\n   }\n   export function aggregate(state, x, weight) {\n     state.count += 1;\n     state.sum += Number(x) * weight;\n   }\n   export function merge(state, partialState) {\n     state.sum += partialState.sum;\n     state.count += partialState.count;\n   }\n   export function finalize(state) {\n     return state.sum / state.count;\n   }\n'''")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_aggregate_js_function());
    }
}