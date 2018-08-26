# Kuriyama Mirai's Stones

##### **Source**: https://codeforces.com

Kuriyama Mirai has killed many monsters and got many (namely n) stones. She numbers the stones from 1 to n. The cost of the i-th stone is Vi. Kuriyama Mirai wants to know something about these stones so she will ask you two kinds of questions:

* She will tell you two numbers, l and r (1 ≤ l ≤ r ≤ n), and you should tell her Sum(Vi, ri).
* Let Ui be the cost of the i-th cheapest stone (the cost that will be on the i-th place if we arrange all the stone costs in non-decreasing order). This time she will tell you two numbers, l and r (1 ≤ l ≤ r ≤ n), and you should tell her Sum(Vi, li).

For every question you should give the correct answer, or Kuriyama Mirai will say "fuyukai desu" and then become unhappy.

##### **Input**
The first line contains an integer n (1 ≤ n ≤ 10^5). The second line contains n integers: v1, v2, ..., vn (1 ≤ vi ≤ 10^9) — costs of the stones.

The third line contains an integer m (1 ≤ m ≤ 10^5) — the number of Kuriyama Mirai's questions. Then follow m lines, each line contains three integers type, l and r (1 ≤ l ≤ r ≤ n; 1 ≤ type ≤ 2), describing a question. If type equal to 1, then you should output the answer for the first question, else you should output the answer for the second one.

##### **Output**
Print m lines. Each line must contain an integer — the answer to Kuriyama Mirai's question. Print the answers to the questions in the order of input.