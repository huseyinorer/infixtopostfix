
**Algorithm: Infix to postfix conversion**
1. Create an empty stack
2. Convert the input string to a list by using string method split
3. Scan the token from left to right
   * If the token is operand append to output list(print)            
   * If the token is left parenthesis push it on the stack        
   * If the token is right parenthesis pop the stack until left parenthesis is removed,append each operator to the output list(print)        
   * If the token is an operator(/*-+) push it on the stack. However first remove any operators already on the stack that have higher or equal precedence and append them to the output list(print)        
5. When the input expression has been completely processed check the stack. Any operators still on the stack can be removed and appended to the output list(print)
