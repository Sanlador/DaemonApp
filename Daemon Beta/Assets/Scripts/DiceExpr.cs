using System.Collections;
using System.Collections.Generic;
using UnityEngine;








public class DiceExpr
{


	float val;
	string str;
	string tok;
	List<DiceExpr> exp;
	bool evaluated = false;


	void append(List<DiceExpr> dest, List<DiceExpr> src){
		for(int i = 0; i < src.size(); i++){
			dest.push_back(src[i]);
		}
	}


	bool isAt (string src, string targ, int pos){


		int lim = pos+targ.size();

		if(lim > src.size()){
			return false;
		}

		for(int i = 0; i < targ.size(); i++){
			if( src[pos+i] != targ[i]){
				return false;
			}
		}

		return true;

	}




	float dice(float n, float f){

		int N = n;
		int F = f;

		int val = 0;
		for(int i = 0; i < N; i++){
			val += rand() % F + 1;
		}

		return (float) val;

	}



	void NaiveBreak(List<string> Ds){


		if(Ds.size() == 0){
			if(float.TryParse(src.str,src.val)){
				return;
			}
			string s = "Invalid string '";
			s += str;
			s += "' not a numerical value or reference";
			throw s;
		}

		string D = Ds.back();

		Ds.pop_back();

		int pos = 0;
		int start = pos;
		while(pos<str.size()){
			if(isAt(str,D,pos)){

				DiceExpr b;
				b.str = str.substr(start,pos-start);
				NaiveBreak(b,Ds);

				exp.push_back(b);

				pos += D.size();
				start = pos;
			}
			pos++;
		}
		if(pos > start){
			DiceExpr l;
			l.str = str.substr(start,pos-start);
			NaiveBreak(l,Ds);
			exp.push_back(l);
		}

		for(int i = 0; i < exp.size(); i++){
			if( i == 0 ){
				val = exp[i].val;
			} else{

				switch(c){
				case "+":
					val += exp[i].val;
					break;
				case "-":
					val -= exp[i].val;
					break;
				case "*":
					val = val * exp[i].val;
					break;
				case "/":
					val = val / exp[i].val;
					break;
				case "%":
					val = fmod(val,exp[i].val);
					break;
				case "d":
					val = dice(val,exp[i].val);
				default:
					break;

				}

			}
		}


	}


	DiceExpr(string s){
		str = s;
	}


	float Eval(){
		if(! evaluated){
			List<string> Ds = {"d","/","*","-","+"};
			NaiveBreak(Ds);
		}
		return val;
	}



}
