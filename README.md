# Minimaxing
![TicTacToe](https://user-images.githubusercontent.com/97398099/186751546-de25c9f0-1299-443d-9e88-aa226d4dc6c0.png)

Hi, in this project i will showcase the basics of minimax and show a simple implementation in TicTacToe.

# What is minimax?
Minimaxing is an algorithm that tries to find the best move for a given situation, whilst assuming that the opponent also plays the best possible move. It is  used in decision-theory, AI, game, theory, etc. But it finds it most succes in simple, turn based board games like TicTacToe. 

# How does it work?
Minimax is a backtracking algorithm, which means plays out every possible situation or move. And then backtracks to make a decision. Every board state has a value or score. This score is unique for every game, it is based on that game its winconditions and the conditions where the player is in a better spot than its opponent.
In minimax you have the maximizer which tries to get the highest score possible. And the minimizer, who tries to get the lowest score possible. 

At the bottom of a decision tree, we give each endnode a score. These are the resulting end states after a decision in their parent node. If it was the maximizers turn in the parent node, it will look for  the highest score. That parent node will now get the value of the highest childnode score. That parent node is also a childnode, its gamestate is a result of a decision made in its parent node by its opponent. Since it is turnbased, logically that was the minimizer. The minimizer will now look for the lowest score in its childnodes and then gat that value. This process repeats until the root node is reached. This way, every node gets a score. If the root node is the maximizer, it will then look at its children and make the move with the highest score. This obviously also works for the minimizer, but it would make the move with the lowest score instead.


