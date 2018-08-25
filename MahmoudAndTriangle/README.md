# Mahmoud and a Triangle

##### **Source**: https://codeforces.com

Mahmoud has n line segments, the i-th of them has length ai. Ehab challenged him to use exactly 3 line segments to form a non-degenerate triangle. Mahmoud doesn't accept challenges unless he is sure he can win, so he asked you to tell him if he should accept the challenge. Given the lengths of the line segments, check if he can choose exactly 3 of them to form a non-degenerate triangle.

Mahmoud should use exactly 3 line segments, he can't concatenate two line segments or change any length. A non-degenerate triangle is a triangle with positive area.

##### **Input**
The first line contains single integer n (3 ≤ n ≤ 10^5) — the number of line segments Mahmoud has.

The second line contains n integers a1, a2, ..., an (1 ≤ ai ≤ 10^9) — the lengths of line segments Mahmoud has.

##### **Output**
In the only line print "YES" if he can choose exactly three line segments and form a non-degenerate triangle with them, and "NO" otherwise.