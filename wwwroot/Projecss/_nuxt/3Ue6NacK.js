var u={kind:"Document",definitions:[{kind:"OperationDefinition",operation:"query",name:{kind:"Name",value:"CreditCalculatorQuery"},variableDefinitions:[{kind:"VariableDefinition",variable:{kind:"Variable",name:{kind:"Name",value:"price"}},type:{kind:"NonNullType",type:{kind:"NamedType",name:{kind:"Name",value:"Int"}}},directives:[]}],directives:[],selectionSet:{kind:"SelectionSet",selections:[{kind:"Field",alias:{kind:"Name",value:"info"},name:{kind:"Name",value:"CreditCalculator"},arguments:[{kind:"Argument",name:{kind:"Name",value:"price"},value:{kind:"Variable",name:{kind:"Name",value:"price"}}}],directives:[]}]}}],loc:{start:0,end:87}};u.loc.source={body:"query CreditCalculatorQuery($price: Int!) {\n    info: CreditCalculator(price: $price)\n}",name:"GraphQL request",locationOffset:{line:1,column:1}};function l(i,e){if(i.kind==="FragmentSpread")e.add(i.name.value);else if(i.kind==="VariableDefinition"){var n=i.type;n.kind==="NamedType"&&e.add(n.name.value)}i.selectionSet&&i.selectionSet.selections.forEach(function(a){l(a,e)}),i.variableDefinitions&&i.variableDefinitions.forEach(function(a){l(a,e)}),i.definitions&&i.definitions.forEach(function(a){l(a,e)})}var f={};(function(){u.definitions.forEach(function(e){if(e.name){var n=new Set;l(e,n),f[e.name.value]=n}})})();function d(i,e){for(var n=0;n<i.definitions.length;n++){var a=i.definitions[n];if(a.name&&a.name.value==e)return a}}function m(i,e){var n={kind:i.kind,definitions:[d(i,e)]};i.hasOwnProperty("loc")&&(n.loc=i.loc);var a=f[e]||new Set,c=new Set,r=new Set;for(a.forEach(function(t){r.add(t)});r.size>0;){var s=r;r=new Set,s.forEach(function(t){if(!c.has(t)){c.add(t);var o=f[t]||new Set;o.forEach(function(v){r.add(v)})}})}return c.forEach(function(t){var o=d(i,t);o&&n.definitions.push(o)}),n}m(u,"CreditCalculatorQuery");export{u as d};
