# Minimaxing
![TicTacToe](https://user-images.githubusercontent.com/97398099/186751546-de25c9f0-1299-443d-9e88-aa226d4dc6c0.png)

Hi, in this project i will showcase the basics of minimax and show a simple implementation in TicTacToe.

# What is minimax?
Minimaxing is an algorithm that tries to find the best move for a given situation, whilst assuming that the opponent also plays the best possible move. It is  used in decision-theory, AI, game, theory, etc. But it finds it most succes in simple, turn based board games like TicTacToe. 

# How does it work?
Minimax is a backtracking algorithm, which means plays out every possible situation or move. And then backtracks to make a decision. Every board state has a value or score. This score is unique for every game, it is based on that game its winconditions and the conditions where the player is in a better spot than its opponent.
In minimax you have the maximizer which tries to get the highest score possible. And the minimizer, who tries to get the lowest score possible. 

At the bottom of a decision tree, we give each endnode a score. These are the resulting end states after a decision in their parent node. If it f.e. was the maximizers turn in the parent node, it will look for  the highest score. That parent node will now get the value of the highest childnode score. That parent node is also a childnode, its gamestate is a result of a decision made in its parent node by its opponent. Since it is turnbased, logically that was the minimizer. The minimizer will now look for the lowest score in its childnodes and then gat that value. This process repeats until the root node is reached. This way, every node gets a score. If the root node is the maximizer, it will then look at its children and make the move with the highest score. This obviously also works for the minimizer, but it would make the move with the lowest score instead.


![Example](https://user-images.githubusercontent.com/97398099/186762765-8c8771ae-519c-4933-b51b-ce51a7a099a0.png)

In this example the root node is the maximizer. It will go for the move with the value of 3, since that is a higher value than -4.

# Implementation in TicTacToe

![FindBestMove](https://user-images.githubusercontent.com/97398099/186763652-bf44ff46-4d8c-42ac-901d-8cf2d6686bed.png)

First i created a find best move function. First we get the current gamestate, then goes over every availale spot in our board and if it is available, it makes that move. After going over every cell it will return the best move based on the results of the minimax.

![WinCheck](https://user-images.githubusercontent.com/97398099/186763675-c2c1e48c-e214-46ce-a1e7-9541fdf48093.png)

In the minimax function, i first call my check for win function to check if it has reached an endstate, in TicTacToe this is a win or tie. If there is a winner i return the score. The maximizer is the AI, so if he wins it returns a score of 1. If the minimizer(the player) wins, it returns a score of -1. If it is a draw, the score is 0. If there is no end state we continue with the minimax function.

![MaximizerMinimizer](https://user-images.githubusercontent.com/97398099/186763687-e5cc174c-445a-4c3e-889c-3f6145a04101.png)

If the current player is the maximizer, it goes over the available cells and makes a move. It then calls minimax again. This recursion happends until a final state has been reached. He does that for every cell and eventually returns the highest score.
The minimizer is very similar, but instead of looking for the highest score, it looks for the lowest score. Eventually these results will go get to the find best move function. Which will then return the best move based on the calculated scores.

https://user-images.githubusercontent.com/97398099/186770003-b4b0205d-ad0e-4d89-888e-538b99af1208.mp4

Because i like to give myself an advantage, the player gets to start in my game. I make the theoretically best move in TicTacToe, which is starting in a corner. But the AI replies with the best possible anwser, which is putting his mark in the middle of the board. I tried my best, but i can't beat my own AI!

# Depth
My AI works, but it can be made better by adding something that i didn't do in my implementation,  called depth. Right now our AI might choose to make a move which results in a slower victory or faster loss. Because it doesn't matter if i win in 2 or 4 moves, the score that i return remains the same. To solve this, we can substract the depth value from the evaluated score. If all results end up as a win, it will choose the fastest victory. I personally didn't find this necessary for this small project. But it can defenitly add value to your AI.

# The downsides
Every algorithm has its downsides. In minimaxing, this is it when it comes to complex games. I used to be a big chessplayer myself and in chess there are almost an infinit amount of possible moves and boardstates. This makes calculating the best move almost impossible. Another problem when it comes to complex games like chess is the score evaluation. You can have more pieces than your opponent. You would think that gives you a higher score evaluation, but that isn't neccesarily the case. Things like positioning, king safety, piece development, etc. can give you a bigger advantage than the extra pawn that you might have. This makes it really difficult to calculate correct scores that are needed for this algorithm.

# Final note
Minimaxing is a very usefull algorithm for simple turn based games like TicTacToe, but struggles in more complex games like chess. I am happy i did my research project about this and i learned some new things! I am certain that i'll use it someday in my programming carreer.

Sources:
https://en.wikipedia.org/wiki/Minimax
https://www.youtube.com/watch?v=l-hh51ncgDI
https://www.geeksforgeeks.org/minimax-algorithm-in-game-theory-set-1-introduction/
https://www.geeksforgeeks.org/minimax-algorithm-in-game-theory-set-3-tic-tac-toe-ai-finding-optimal-move/
https://www.javatpoint.com/mini-max-algorithm-in-ai#:~:text=The%20main%20drawback%20of%20the,lots%20of%20choices%20to%20decide.

