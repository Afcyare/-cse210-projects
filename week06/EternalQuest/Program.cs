using System;
/*
 * ===== EXCEEDED REQUIREMENTS =====
 * 
 * 1. **Leveling System & Achievements**
 *    - Added XP tracking and level-ups (every 1000 XP, scaled by level).
 *    - Earn badges for milestones (e.g., "Goal Master" for 10 completed goals).
 *    - Visual fanfare for achievements (color, ASCII art).
 * 
 * 2. **Enhanced UI/UX**
 *    - Color-coded goal displays (green for complete, cyan for eternal goals).
 *    - Progress bars for ChecklistGoals (e.g., "■■■■□ 4/5").
 *    - Milestone bonuses for EternalGoals (double points every 10 completions).
 * 
 * 3. **Advanced Save/Load**
 *    - Save/Load all progress (XP, level, achievements) alongside goals.
 *    - Robust error handling for file operations.
 * 
 * 4. **Additional Features**
 *    - "View Achievements" menu option.
 *    - Input validation for all user prompts.
 *    - Reset protection (auto-recover corrupted saves).
 */
 
class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        manager.Start(); // This launches the interactive menu
    }
}