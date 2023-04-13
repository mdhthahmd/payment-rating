<script setup>
import { ref } from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/24/outline'
import { LinkIcon, PlusIcon, QuestionMarkCircleIcon } from '@heroicons/vue/20/solid'


const transactions = [
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    {
        id: 'AAPS0L',
        company: 'Chase & Co.',
        share: 'CAC',
        commission: '+$4.37',
        price: '$3,509.00',
        quantity: '12.00',
        netAmount: '$4,397.00',
    },
    // More transactions...
]




const team = [


    {
        name: 'Tom Cook',
        email: 'tom.cook@example.com',
        href: '#',
        imageUrl:
            'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    {
        name: 'Whitney Francis',
        email: 'whitney.francis@example.com',
        href: '#',
        imageUrl:
            'https://images.unsplash.com/photo-1517365830460-955ce3ccd263?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    {
        name: 'Leonard Krasner',
        email: 'leonard.krasner@example.com',
        href: '#',
        imageUrl:
            'https://images.unsplash.com/photo-1519345182560-3f2917c472ef?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    {
        name: 'Floyd Miles',
        email: 'floyd.miles@example.com',
        href: '#',
        imageUrl:
            'https://images.unsplash.com/photo-1463453091185-61582044d556?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    {
        name: 'Emily Selman',
        email: 'emily.selman@example.com',
        href: '#',
        imageUrl:
            'https://images.unsplash.com/photo-1502685104226-ee32379fefbe?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
]

const open = ref(false)
const contributionDate = ref();
const paidDate = ref();
const paymentStatus = ref();




</script>

<template>
    <TransitionRoot as="template" :show="open">
        <Dialog as="div" class="relative z-10" @close="open = false">
            <TransitionChild as="template" enter="ease-in-out duration-500" enter-from="opacity-0" enter-to="opacity-100"
                leave="ease-in-out duration-500" leave-from="opacity-100" leave-to="opacity-0">
                <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
            </TransitionChild>

            <div class="fixed inset-0 overflow-hidden">
                <div class="absolute inset-0 overflow-hidden">
                    <div class="pointer-events-none fixed inset-y-0 right-0 flex max-w-full pl-10">
                        <TransitionChild as="template" enter="transform transition ease-in-out duration-500 sm:duration-700"
                            enter-from="translate-x-full" enter-to="translate-x-0"
                            leave="transform transition ease-in-out duration-500 sm:duration-700" leave-from="translate-x-0"
                            leave-to="translate-x-full">
                            <DialogPanel class="pointer-events-auto w-screen max-w-md">
                                <form class="flex h-full flex-col divide-y divide-gray-200 bg-white shadow-xl">
                                    <div class="h-0 flex-1 overflow-y-auto">
                                        <div class="bg-red-700 px-4 py-6 sm:px-6">
                                            <div class="flex items-center justify-between">
                                                <DialogTitle class="text-base font-semibold leading-6 text-white">New
                                                    Payment</DialogTitle>
                                                <div class="ml-3 flex h-7 items-center">
                                                    <button type="button"
                                                        class="rounded-md bg-red-700 text-red-200 hover:text-white focus:outline-none focus:ring-2 focus:ring-white"
                                                        @click="open = false">
                                                        <span class="sr-only">Close panel</span>
                                                        <XMarkIcon class="h-6 w-6" aria-hidden="true" />
                                                    </button>
                                                </div>
                                            </div>
                                            <div class="mt-1">
                                                <p class="text-sm text-red-100">Please fill in the information below to
                                                    create a new payment.</p>
                                            </div>
                                        </div>
                                        <div class="flex flex-1 flex-col justify-between">
                                            <div class="divide-y divide-gray-200 px-4 sm:px-6">
                                                <div class="space-y-6 pb-5 pt-6">
                                                    <div>
                                                        <label for="contribution-month"
                                                            class="block text-sm font-medium leading-6 text-gray-900">Contribution
                                                            Month</label>
                                                        <div class="mt-2">
                                                            <VueDatePicker v-model="contributionDate"
                                                                :enable-time-picker="false"></VueDatePicker>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <label for="payment-amount"
                                                            class="block text-sm font-medium leading-6 text-gray-900">Amount</label>
                                                        <div class="mt-2">
                                                            <label for="price"
                                                                class="block text-sm font-medium leading-6 text-gray-900">Price</label>
                                                            <div class="relative mt-2 rounded-md shadow-sm">
                                                                <div
                                                                    class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3">
                                                                    <span class="text-gray-500 sm:text-sm">$</span>
                                                                </div>
                                                                <input type="text" name="price" id="price"
                                                                    class="block w-full rounded-md border-0 py-1.5 pl-7 pr-12 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-red-600 sm:text-sm sm:leading-6"
                                                                    placeholder="0.00" aria-describedby="price-currency" />
                                                                <div
                                                                    class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-3">
                                                                    <span class="text-gray-500 sm:text-sm"
                                                                        id="price-currency">MVR</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <label for="payment-date"
                                                            class="block text-sm font-medium leading-6 text-gray-900">Payment
                                                            Date</label>
                                                        <div class="mt-2">
                                                            <VueDatePicker v-model="paidDate" :enable-time-picker="false">
                                                            </VueDatePicker>
                                                        </div>
                                                    </div>
                                                    <fieldset>
                                                        <legend class="text-sm font-medium leading-6 text-gray-900">Payment
                                                            Status</legend>
                                                        <div class="mt-2 space-y-4">
                                                            <div class="relative flex items-start">
                                                                <div class="absolute flex h-6 items-center">
                                                                    <input id="privacy-public" name="privacy"
                                                                        aria-describedby="privacy-public-description"
                                                                        type="radio"
                                                                        class="h-4 w-4 border-gray-300 text-red-600 focus:ring-red-600"
                                                                        checked="" />
                                                                </div>
                                                                <div class="pl-7 text-sm leading-6">
                                                                    <label for="privacy-public"
                                                                        class="font-medium text-gray-900">Pending</label>
                                                                    <p id="privacy-public-description"
                                                                        class="text-gray-500">Everyone with the link will
                                                                        see this project.</p>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <div class="relative flex items-start">
                                                                    <div class="absolute flex h-6 items-center">
                                                                        <input id="privacy-private-to-project"
                                                                            name="privacy"
                                                                            aria-describedby="privacy-private-to-project-description"
                                                                            type="radio"
                                                                            class="h-4 w-4 border-gray-300 text-red-600 focus:ring-red-600" />
                                                                    </div>
                                                                    <div class="pl-7 text-sm leading-6">
                                                                        <label for="privacy-private-to-project"
                                                                            class="font-medium text-gray-900">Paid</label>
                                                                        <p id="privacy-private-to-project-description"
                                                                            class="text-gray-500">Only members of this
                                                                            project would be able to access.</p>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </fieldset>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="flex flex-shrink-0 justify-end px-4 py-4">
                                        <button type="button"
                                            class="rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
                                            @click="open = false">Cancel</button>
                                        <button type="submit"
                                            class="ml-4 inline-flex justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-red-600">Add
                                            Payment</button>
                                    </div>
                                </form>
                            </DialogPanel>
                        </TransitionChild>
                    </div>
                </div>
            </div>
        </Dialog>
    </TransitionRoot>

    <div class="py-10">
        <header>
            <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
                <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Payments</h1>
            </div>
        </header>
        <main>
            <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">

                <!-- Content -->
                <div class="px-4 py-8 sm:px-0">


                    <div class="sm:flex sm:items-center">
                        <div class="sm:flex-auto">
                            <h1 class="text-base font-semibold leading-6 text-gray-900">Payment History</h1>
                            <p class="mt-2 text-sm text-gray-700">A table of placeholder stock market data that does not
                                make any sense.</p>
                        </div>
                        <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
                            <button @click="open = true" type="button"
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
                                                Transaction ID</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Company</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Share</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Commision</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Price</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Quantity</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Net amount</th>
                                            <th scope="col" class="relative whitespace-nowrap py-3.5 pl-3 pr-4 sm:pr-0">
                                                <span class="sr-only">Edit</span>
                                            </th>
                                        </tr>
                                </thead>
                                <tbody class="divide-y divide-gray-200 bg-white">
                                    <tr v-for="transaction in transactions" :key="transaction.id">
                                        <td class="whitespace-nowrap py-2 pl-4 pr-3 text-sm text-gray-500 sm:pl-0">{{
                                            transaction.id }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm font-medium text-gray-900">{{
                                            transaction.company }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-900">{{
                                            transaction.share }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            transaction.commission }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            transaction.price }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            transaction.quantity }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            transaction.netAmount }}</td>
                                        <td
                                            class="relative whitespace-nowrap py-2 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                                            <a href="#" class="text-red-600 hover:text-red-900">Edit<span
                                                    class="sr-only">, {{ transaction.id }}</span></a>
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