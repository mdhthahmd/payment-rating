<script setup>
import { ref } from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/20/solid'
import { InformationCircleIcon, NewspaperIcon } from '@heroicons/vue/24/outline'
import axios from 'axios'

import dayjs from 'dayjs'
import customParseFormat  from 'dayjs/plugin/customParseFormat'
dayjs.extend(customParseFormat)

const employers = ref()
const selectedEmployer = ref(0)
const newAmount = ref(0)
const newContributionMonth = ref(0)
const newContributionYear = ref(0)


axios.get("api/employers/dropdown")
.then(response => employers.value = response.data)


const PagedPaymentList = ref({})

const openModal = ref(false)
const openOverlay = ref(false)

const companyName = ref('')
const amount = ref(0)
const period = ref('')

const paymentId = ref()
const employerId = ref()

axios
    .get("api/payments/pending")
    .then(response => PagedPaymentList.value = response.data);


const CurrencyFormatter = new Intl.NumberFormat('en-US', {
  style: 'currency',
  currency: 'USD',
});

function clickedMakePayment(payment)
{
    console.log(payment.amount, payment.employer, payment.contributionMonth)
    companyName.value = payment.employer;
    employerId.value = payment.employerId;
    paymentId.value = payment.id;
    amount.value = payment.amount;
    period.value = dayjs(payment.contributionMonth).format('YYYY/MM');
    openModal.value = true;
}

function MakePayment()
{
    let url = `api/employers/${employerId.value}/payments/${paymentId.value}`;
    axios.post(url, {})
        .then(response => { 
            axios
            .get("api/payments/pending")
            .then(response => PagedPaymentList.value = response.data);

            openModal.value = false;
        })

}

function CreateNewPayment()
{
    openOverlay.value = false;
    console.log(selectedEmployer.value, newAmount.value, newContributionMonth.value.month);

    var uri = `api/employers/${selectedEmployer.value}/payments`
    axios.post(uri, {
        EmployerId : selectedEmployer.value,
        Month : newContributionMonth.value.month,
        Year:  newContributionMonth.value.year,
        Amount: newAmount.value
    })
    .then(response => {});


}

</script>

<template>
<TransitionRoot as="template" :show="openOverlay">
    <Dialog as="div" class="relative z-10" @close="openOverlay = false">
      <TransitionChild as="template" enter="ease-in-out duration-500" enter-from="opacity-0" enter-to="opacity-100" leave="ease-in-out duration-500" leave-from="opacity-100" leave-to="opacity-0">
        <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
      </TransitionChild>

      <div class="fixed inset-0 overflow-hidden">
        <div class="absolute inset-0 overflow-hidden">
          <div class="pointer-events-none fixed inset-y-0 right-0 flex max-w-full pl-10 sm:pl-16">
            <TransitionChild as="template" enter="transform transition ease-in-out duration-500 sm:duration-700" enter-from="translate-x-full" enter-to="translate-x-0" leave="transform transition ease-in-out duration-500 sm:duration-700" leave-from="translate-x-0" leave-to="translate-x-full">
              <DialogPanel class="pointer-events-auto w-screen max-w-md">
                <form class="flex h-full flex-col divide-y divide-gray-200 bg-white shadow-xl">
                  <div class="h-0 flex-1 overflow-y-auto">
                    <div class="bg-red-700 px-4 py-6 sm:px-6">
                      <div class="flex items-center justify-between">
                        <DialogTitle class="text-base font-semibold leading-6 text-white">New Payment</DialogTitle>
                        <div class="ml-3 flex h-7 items-center">
                          <button type="button" class="rounded-md bg-red-700 text-red-200 hover:text-white focus:outline-none focus:ring-2 focus:ring-white" @click="openOverlay = false">
                            <span class="sr-only">Close panel</span>
                            <XMarkIcon class="h-6 w-6" aria-hidden="true" />
                          </button>
                        </div>
                      </div>
                      <div class="mt-1">
                        <p class="text-sm text-red-100">Fill in the following fields to add a new payment.</p>
                      </div>
                    </div>
                    <div class="flex flex-1 flex-col justify-between">
                      <div class="divide-y divide-gray-200 px-4 sm:px-6">
                        <div class="space-y-6 pb-5 pt-6">
                            <div>
                                <label for="company" class="block text-sm font-medium leading-6 text-gray-900">Employer</label>
                                <select  v-model="selectedEmployer"  id="company" name="company" class="mt-2 block w-full rounded-md border-0 py-1.5 pl-3 pr-10 text-gray-900 ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-red-600 sm:text-sm sm:leading-6">
                                <option selected="">Please Select an Employer</option>
                                <option :value="company.id" v-for="company in employers" :key="company.id">{{ company.name }}</option>
                                </select>
                            </div>

                          <div>
                            <label for="contribution-month" class="block text-sm font-medium leading-6 text-gray-900">Contribution Month</label>
                            <div class="mt-2">
                              <!-- <input type="text" id="contribution-month" name="contribution-month" rows="4" class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-red-600 sm:text-sm sm:leading-6" /> -->
                              <VueDatePicker v-model="newContributionMonth" month-picker></VueDatePicker>
                            </div>
                          </div>
                          


                          <div>
                            <label for="contribution-amount" class="block text-sm font-medium leading-6 text-gray-900">Amount</label>
                            <div class="relative mt-2 rounded-md shadow-sm">
                            <input v-model="newAmount" type="text" name="contribution-amount" id="contribution-amount" class="block w-full rounded-md border-0 py-1.5 pl-4 pr-12 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-red-600 sm:text-sm sm:leading-6" placeholder="0.00" aria-describedby="price-currency" />
                            <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-3">
                                <span class="text-gray-500 sm:text-sm" id="contribution-amount-currency">MVR</span>
                            </div>
                            </div>
                        </div>
                        
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="flex flex-shrink-0 justify-end px-4 py-4">
                    <button type="button" class="rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50" @click="openOverlay = false">Cancel</button>
                    <button @click.prevent="CreateNewPayment" type="button" class="ml-4 inline-flex justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-red-600">Save</button>
                  </div>
                </form>
              </DialogPanel>
            </TransitionChild>
          </div>
        </div>
      </div>
    </Dialog>
  </TransitionRoot>


<TransitionRoot as="template" :show="openModal">
    <Dialog as="div" class="relative z-10" @close="openModal = false">
      <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0" enter-to="opacity-100" leave="ease-in duration-200" leave-from="opacity-100" leave-to="opacity-0">
        <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
      </TransitionChild>

      <div class="fixed inset-0 z-10 overflow-y-auto">
        <div class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
          <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95" enter-to="opacity-100 translate-y-0 sm:scale-100" leave="ease-in duration-200" leave-from="opacity-100 translate-y-0 sm:scale-100" leave-to="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95">
            <DialogPanel class="relative transform overflow-hidden rounded-lg bg-white px-4 pb-4 pt-5 text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-lg sm:p-6">
              <div>
                <div class="mx-auto flex h-12 w-12 items-center justify-center rounded-full bg-green-100">
                  <InformationCircleIcon class="h-6 w-6 text-green-600" aria-hidden="true" />
                </div>
                <div class="mt-3 text-center sm:mt-5">
                  <DialogTitle as="h3" class="text-base font-semibold leading-6 text-gray-900">Confirmation</DialogTitle>
                  <div class="mt-2">
                    <p class="text-sm text-gray-500">You are about to make a 
                        <span class="text-green-600">{{ CurrencyFormatter.format(amount) }}</span> 
                        payment on behalf of 
                        <br>
                        <span class="text-semibold text-gray-950">{{ companyName }}</span> 
                        <br>
                        for month
                        <span class="text-semibold text-gray-950">{{ period }}</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="mt-5 sm:mt-6 sm:grid sm:grid-flow-row-dense sm:grid-cols-2 sm:gap-3">
                <button type="button" class="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-red-600 sm:col-start-2" @click="MakePayment">Make Payment</button>
                <button type="button" class="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:col-start-1 sm:mt-0" @click="openModal = false" ref="cancelButtonRef">Cancel</button>
              </div>
            </DialogPanel>
          </TransitionChild>
        </div>
      </div>
    </Dialog>
  </TransitionRoot>


    <div class="py-10">
        <header>
            <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
                <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Pending</h1>
            </div>
        </header>
        <main>
            <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">

                <!-- Content -->
                <div class="px-4 py-8 sm:px-0">


                    <div class="sm:flex sm:items-center">
                        <div class="sm:flex-auto">
                            <h1 class="text-base font-semibold leading-6 text-gray-900">Pending Payments</h1>
                            <p class="mt-2 text-sm text-gray-700">A table of all payments that have not been yet recevied from employers</p>
                        </div>
                        <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
                            <button @click="openOverlay = true" type="button"
                                class="block rounded-md bg-red-600 px-3 py-2 text-center text-sm font-semibold text-white shadow-sm hover:bg-red-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-red-600">Add
                                Payment</button>
                        </div>
                    </div>
                    <div class="mt-8 flow-root">
                        <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                            <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
                                <table class="min-w-full divide-y divide-gray-300">
                                    <thead>
                                        <tr>
                                            <th scope="col"
                                                class="whitespace-nowrap py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-gray-900 sm:pl-0">
                                                #</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Month</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Company</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-right text-sm font-semibold text-gray-900">
                                                Amount</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-center text-sm font-semibold text-gray-900">
                                                Due Date</th>
                                            <th scope="col" class="relative whitespace-nowrap py-3.5 pl-3 pr-4 sm:pr-0">
                                                <span class="sr-only">Make Payment</span>
                                            </th>

                                            
                                        </tr>
                                </thead>
                                <tbody class="divide-y divide-gray-200 bg-white">
                                    <tr v-for="payment in PagedPaymentList.data" :key="payment.id">
                                        <td class="whitespace-nowrap py-2 pl-4 pr-3 text-sm text-gray-500 sm:pl-0">{{
                                            payment.id }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            dayjs(payment.contributionMonth).format('YYYY/MM') }}</td>    
                                        <td class="whitespace-nowrap px-2 py-2 text-sm font-medium text-gray-900">{{
                                            payment.employer }}</td> 
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-right font-medium text-red-500">{{
                                            CurrencyFormatter.format(payment.amount) }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-center text-sm text-gray-900">{{
                                            dayjs(payment.dueDate).format('DD MMMM YYYY') }}</td>
                                        <td class="relative whitespace-nowrap py-2 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                                            <p v-on:click="clickedMakePayment(payment)" class="cursor-pointer text-orange-400 hover:text-orange-500 hover:underline">
                                                Make Payment<span class="sr-only">, {{ payment.id }}</span>
                                            </p>
                                        </td>
                                                                           
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <nav class="flex items-center justify-between border-t border-gray-200 bg-white py-3"
                    aria-label="Pagination">
                    <div class="hidden sm:block">
                        <p class="text-sm text-gray-700">
                            Showing
                            {{ ' ' }}
                            <span class="font-medium">1</span>
                            {{ ' ' }}
                            to
                            {{ ' ' }}
                            <span class="font-medium">10</span>
                            {{ ' ' }}
                            of
                            {{ ' ' }}
                            <span class="font-medium">20</span>
                            {{ ' ' }}
                            results
                        </p>
                    </div>
                    <div class="flex flex-1 justify-between sm:justify-end">
                        <a href="#"
                            class="relative inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Previous</a>
                        <a href="#"
                            class="relative ml-3 inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Next</a>
                    </div>
                </nav>



            </div>
            <!-- /End Content -->

        </div>
    </main>
</div></template>