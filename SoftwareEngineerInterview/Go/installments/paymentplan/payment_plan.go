package paymentplan

import (
	"github.com/google/uuid"
	"github.com/quadpay/software-engineer-interview/SoftwareEngineerInterview/Go/installments/installment"
)

// PaymentPlan is a structure that defines all the properties for a payment plan.
type PaymentPlan struct {
	id             uuid.UUID
	purchaseAmount float64
	installments   []installment.Installment
}

// Id gets the unique identifier for each payment plan.
func (p PaymentPlan) Id() uuid.UUID {
	return p.id
}

// SetId sets the unique identifier for each payment plan.
func (p PaymentPlan) SetId(id uuid.UUID) {
	p.id = id
}

// PurchaseAmount gets the purchase amount for each payment plan.
func (p PaymentPlan) PurchaseAmount() float64 {
	return p.purchaseAmount
}

// SetPurchaseAmount sets the purchase amount for each payment plan.
func (p PaymentPlan) SetPurchaseAmount(purchaseAmount float64) {
	p.purchaseAmount = purchaseAmount
}

// Installments gets the installments for each payment plan.
func (p PaymentPlan) Installments() []installment.Installment {
	return p.installments
}

// SetInstallments sets the installments for each payment plan.
func (p PaymentPlan) SetInstallments(installments []installment.Installment) {
	p.installments = installments
}

// New creates a new payment plan according to purchase amount.
func New(purchaseAmount float64) (PaymentPlan, error) {
	// TODO
	return PaymentPlan{}, nil
}
