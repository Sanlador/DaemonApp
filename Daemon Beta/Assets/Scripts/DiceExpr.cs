using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dexpr {
	VAL,
	ROL,
	PAR,
	MUL,
	DIV,
	MOD,
	ADD,
	SUB,
};

public class DiceExpr
{
/*
	Dexpr type;
	List<string> content;
	List<DiceExpr> subExprs;


	List<List<string>> SplitBy(List<string> tokens,string[] delims){
		List<List<string>> results = new List<List<string>>();
		results.Add(new List<string>());
		foreach(string token in tokens){
			if(Array.Exists(delims, d=> (token.Contains(d)))){
				string[] sp = token.Split(delims);
				foreach(string s in sp){
					if(delims.Contains(s)){
						results.Add(new List<string>());
					} else if(s.Length > 0) {
						results[results.Count - 1].Add(s);
					}
				}
			} else {
				results[results.Count - 1].Add(token);
			}
		}
		return results;
	}


	DiceExpr ExprChain (List<List<string>> sections, List<Dexpr> ) {
		DiceExpr result = new DiceExpr();
		for( int i = sections.Count-2; i >= 0; i--){
			
		}
	}


	DiceExpr Mathify(List<string> tokens){
		string[] rolDelims = {"d"};
		List<List<string>> rolls = SplitBy (tokens,roldelims);


	}


	DiceExpr Parify(){
		int idx = first;

		List<string> subStrs = new List<string>();

		while(){
			while(!content[idx].Equals("(")){
				subStrs.Add(content[first]);
				first++;
				if(first >= content.Count()){
					break;
				}
			}
		}

	}


	string Valify(){

	}

	List<string> Mulify(){

	}


	List<string> Addify(){

	}


	DiceExpr(List<string> tokens, Dexpr dexpr_type){
		type = dexpr_type;
		content = tokens;

		switch(type){
		case Dexpr.VAL:
			Val
			break;
		case Dexpr.ROL:

			break;
		case Dexpr.PAR:

			break;
		case Dexpr.MUL:

			break;
		case Dexpr.DIV:

			break;
		case Dexpr.MOD:

			break;
		case Dexpr.ADD:

			break;
		case Dexpr.SUB:

			break;

		}

	}
*/

}
