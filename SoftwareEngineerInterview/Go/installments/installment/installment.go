package installment

import (
	"time"

	"github.com/google/uuid"
)

// Installment is a structure that defines all the properties for an installment.
type Installment struct {
	id      uuid.UUID
	dueDate time.Time
	amount  float64
}

// Id gets the unique identifier for each installment.
func (i Installment) Id() uuid.UUID {
	return i.id
}

// SetId sets the unique identifier for each installment.
func (i Installment) SetId(id uuid.UUID) {
	i.id = id
}

// DueDate gets the due date for each installment.
func (i Installment) DueDate() time.Time {
	return i.dueDate
}

// SetDueDate sets the due date for each installment.
func (i Installment) SetDueDate(dueDate time.Time) {
	i.dueDate = dueDate
}

// Amount gets the installment amount.
func (i Installment) Amount() float64 {
	return i.amount
}

// SetAmount sets the installment amount.
func (i Installment) SetAmount(amount float64) {
	i.amount = amount
}
