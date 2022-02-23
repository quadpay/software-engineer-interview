package paymentplan

import "testing"

func TestCreateNewPaymentPlanWithValidOrderAmount(t *testing.T) {
	_, err := New(123.45)

	if err != nil {
		t.Errorf("creating payment plan error: %v", err)
	}
}
