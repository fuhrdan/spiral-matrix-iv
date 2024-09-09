//*****************************************************************************
//** 2326. Spiral Matrix IV  leetcode                                        **
//*****************************************************************************


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int** spiralMatrix(int m, int n, struct ListNode* head, int* returnSize, int** returnColumnSizes) {
    // Allocate memory for the matrix
    int** retMatrix = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        retMatrix[i] = (int*)malloc(n * sizeof(int));
        for (int j = 0; j < n; j++) {
            retMatrix[i][j] = -1;  // Initialize all elements to -1
        }
    }

    // Initialize returnColumnSizes array to store the number of columns for each row
    *returnColumnSizes = (int*)malloc(m * sizeof(int));
    for (int i = 0; i < m; i++) {
        (*returnColumnSizes)[i] = n;  // Each row has n columns
    }
    *returnSize = m;  // The number of rows in the matrix

    // Spiral matrix filling
    int top = 0, bottom = m - 1, left = 0, right = n - 1;
    while (top <= bottom && left <= right && head) {
        // Fill top row (left to right)
        for (int i = left; i <= right && head; i++) {
            retMatrix[top][i] = head->val;
            head = head->next;
        }
        top++;

        // Fill right column (top to bottom)
        for (int i = top; i <= bottom && head; i++) {
            retMatrix[i][right] = head->val;
            head = head->next;
        }
        right--;

        // Fill bottom row (right to left)
        for (int i = right; i >= left && head; i--) {
            retMatrix[bottom][i] = head->val;
            head = head->next;
        }
        bottom--;

        // Fill left column (bottom to top)
        for (int i = bottom; i >= top && head; i--) {
            retMatrix[i][left] = head->val;
            head = head->next;
        }
        left++;
    }

    return retMatrix;
}