# Slot Machine Game

## Game Overview
A classic slot machine game built in Unity. 
The player selects a bet amount, pulls the lever, 
and wins if all 3 reels show the same symbol.

## How to Play
1. Game starts with 100G coins
2. Select your bet — 10G, 50G, or 100G
3. Lever pulls automatically and reels spin
4. Match all 3 symbols to win!

## Symbols and Payouts
| Symbol | Payout |
|--------|--------|
| Cherry | 2x bet |
| Bell   | 2x bet |
| BAR    | 2x bet |
| Seven  | 5x bet (Jackpot!) |

## How to Run WebGL Build
1. Clone this repository
2. Open the `/WebGL build` folder
3. Open `index.html` in a web browser

## Thought Process
- Used Unity UI system with Canvas for all game elements
- Implemented RNG using Unity's Random.Range for fair outcomes
- Separated concerns with individual scripts:
  - GameManager: handles coins and bet logic
  - ReelController: handles symbol shuffling per reel
  - SlotManager: controls spin flow and win detection
  - BetUI: manages bet selection popup
  - LeverAnimator: handles lever animation and spin trigger
