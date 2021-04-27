	These tests are written for Chrome browser.
Brief summary of each test:
	Test 1.
1. Opens Google
2. Searches KPI schedule website
3. Navigates to found schedule website
4. Finds schedule for my group
5. Gets first subject on Wednesday
6. Compares found subject with expected
Test success condition: found subject is identical to expected

	Test 2.
1. Opens Google
2. Searches Epicenter website
3. Navitages to found schedule website
4. Navigates to "Contacts" section
5. Gets call center working hours information
6. Checks whether expected working hours are present in found information
Test success condition: specified hours occur in found information string

	Test 3.
1. Opens Google
2. Searches for specified video title
3. Navitages to first found video
4. Gets amount of views
5. Compares actual amount of views with expected amount
Test success condition: actual views are greater or equal than expected